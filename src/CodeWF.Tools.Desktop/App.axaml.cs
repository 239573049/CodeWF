namespace CodeWF.Tools.Desktop;

public class App : PrismApplication
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        base.Initialize(); // <-- Required
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        base.ConfigureModuleCatalog(moduleCatalog);

        moduleCatalog.AddModule<DeveloperModule>();
        moduleCatalog.AddModule<WebModule>();
        moduleCatalog.AddModule<TestModule>();
    }

    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        base.ConfigureRegionAdapterMappings(regionAdapterMappings);

        regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(Grid), Container.Resolve<GridRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(TabControl), Container.Resolve<TabControlAdapter>());
    }

    protected override AvaloniaObject CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        var container = containerRegistry.GetContainer();
        // Views - Generic
        containerRegistry.Register<MainWindow>();

        var regionManager = Container.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion<DashboardView>(RegionNames.ContentRegion);
        regionManager.RegisterViewWithRegion<FooterView>(RegionNames.FooterRegion);

        containerRegistry.RegisterSingleton(typeof(FooterViewModel));
        containerRegistry.RegisterSingleton(typeof(DashboardViewModel));

        containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
        containerRegistry.RegisterSingleton<IClipboardService, ClipboardService>();
        containerRegistry.RegisterSingleton<IToolManagerService, ToolManagerService>();

        var toolManagerService = container.Resolve<IToolManagerService>();
        toolManagerService.AddTool("��ҳ",
            "����һ������Avalonia UI + Prism��ܴ����ģ�黯��ƽ̨����ƽ̨��������ڶ࿪��ʵ��С���ߣ�Ŀǰ�ѿ����򼴽��������������롢���ݼ��ܵȣ�������ǿ�󣬿��伴�ã�������������������Ч�ʡ�",
            nameof(DashboardView), ToolStatus.Complete);
    }

    /// <summary>
    /// 1��DryIoc.Microsoft.DependencyInjection�Ͱ汾�ɲ�Ҫ���������5.1.0�����£�
    /// 2���߰汾���룬������׳��쳣��System.MissingMethodException:��Method not found: 'DryIoc.Rules DryIoc.Rules.WithoutFastExpressionCompiler()'.��
    /// �ο�issues��https://github.com/dadhi/DryIoc/issues/529
    /// </summary>
    /// <returns></returns>
    protected override Rules CreateContainerRules()
    {
        return Rules.Default.WithConcreteTypeDynamicRegistrations(reuse: Reuse.Transient)
            .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
            .WithFuncAndLazyWithoutRegistration()
            .WithTrackingDisposableTransients()
            //.WithoutFastExpressionCompiler()
            .WithFactorySelector(Rules.SelectLastRegisteredFactory());
    }

    protected override IContainerExtension CreateContainerExtension()
    {
        IContainer container = new Container(CreateContainerRules());
        container.WithDependencyInjectionAdapter();

        return new DryIocContainerExtension(container);
    }

    protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterRequiredTypes(containerRegistry);

        IServiceCollection services = ConfigureServices();

        IContainer container = ((IContainerExtension<IContainer>)containerRegistry).Instance;

        container.Populate(services);
    }

    private static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        // ע��MediatR
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

        // ���ģ��ע�룬δ��ʾ����ģ������ǰ��ģ�������δ���ص���ǰ������`AppDomain.CurrentDomain`��
        var assembly = typeof(TestModule).GetAssembly();
        assemblies.Add(assembly);
        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssemblies(assemblies.ToArray());
        });

        return services;
    }
}