using CodeWF.WebAPI.Options;
using CodeWF.WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CodeWF.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController(
    ILogger<HomeController> logger,
    IOptions<SiteOption> siteOptions,
    IMemoryCache memoryCache)
    : ControllerBase
{
    /// <summary>
    ///     ��ȡ������������
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetBase")]
    public async Task<SiteBase?> GetAsync()
    {
        var baseInfo = new SiteBase
        {
            Base = new SiteInfo
            {
                Name = siteOptions.Value.Name,
                Memo = siteOptions.Value.Memo,
                Logo = siteOptions.Value.Logo,
                Owner = siteOptions.Value.Owner,
                OwnerWeChat = siteOptions.Value.OwnerWeChat,
                WeChatPublic = siteOptions.Value.WeChatPublic,
                Start = siteOptions.Value.Start,
                ToolUrl = siteOptions.Value.ToolUrl,
                BlogPostUrl = siteOptions.Value.BlogPostUrl
            },
            Tools = new List<ToolItem>
            {
                new()
                {
                    Name = "��ά��������", Memo = "���ɲ�����url���ı���QR���룬���Զ��屳����ǰ����ɫ��",
                    Url = "https://tools.dotnet9.com/qrcode-generator",
                    Cover = "https://img1.dotnet9.com/site/wechatpublic.jpg"
                },

                new()
                {
                    Name = "����ʱ��ת����", Memo = "�����ں�ʱ��ת��Ϊ���ֲ�ͬ�ĸ�ʽ",
                    Url = "https://tools.dotnet9.com/date-converter",
                    Cover = "https://img1.dotnet9.com/site/wechatpublic.jpg"
                },

                new()
                {
                    Name = "������ת����", Memo = "�ڲ�ͬ�Ļ�����ʮ���ơ�ʮ�����ơ������ơ��˽��ơ�base64����֮��ת������",
                    Url = "https://tools.dotnet9.com/base-converter",
                    Cover = "https://img1.dotnet9.com/site/wechatpublic.jpg"
                },
                new()
                {
                    Name = "�����ַ���", Memo = "ȷ���ַ��� url���ļ����� id ��ȫ��",
                    Url = "https://tools.dotnet9.com/slugify-string",
                    Cover = "https://img1.dotnet9.com/site/wechatpublic.jpg"
                }
            },
            BlogPosts = new List<BlogPostItem>
            {
                new()
                {
                    Title = "NetBeauty2�������.NET��Ŀ���Ŀ¼����ˬ",
                    Memo =
                        "��.NET��Ŀ�����У�������Ŀ�����Ե����ӣ�������dll�ļ�Ҳ�������ࡣ�������������Ŀ¼���ң������ڹ���Ͳ��𡣶�NetBeauty2��Դ��Ŀ����Ϊ�˽����һ������������ܹ������������ڶ�������.NET��Ŀʱ����.NET����ʱ��������dll�ļ��ƶ���ָ����Ŀ¼���Ӷ������Ŀ¼���Ӹɾ�����ˬ��",
                    Cover = "https://img1.dotnet9.com/2024/03/cover_06.png",
                    Url =
                        "https://blog.dotnet9.com/post/2024/3/12/netbeauty2-let-your-dotnet-project-output-directory-is-more-refreshing"
                },
                new()
                {
                    Title = ".NET��ƽ̨�ͻ��˿�� - Avalonia UI",
                    Memo =
                        "����һ������WPF XAML�Ŀ�ƽ̨UI��ܣ���֧�ֶ��ֲ���ϵͳ��Windows��.NET Core����Linux��GTK����MacOS��Android��iOS����Web��WebAssembly��",
                    Cover = "https://img1.dotnet9.com/2022/11/0402.png",
                    Url =
                        "https://blog.dotnet9.com/post/2022/11/19/one-of-the-best-choices-for-dotnet-cross-platform-frameworks-avalonia-ui"
                },
                new()
                {
                    Title = "���汾����ϵͳ��.NET֧�����",
                    Memo = "����������Ͳ��Ի��������汾����ϵͳ��.NET��֧���������װ����ϵͳ��ʵ�ⰲװ��Ӧ����ʱ���ܹ������ǳ�����Ϊͨ����",
                    Cover = "https://img1.dotnet9.com/2024/01/cover_02.png",
                    Url =
                        "https://blog.dotnet9.com/post/2024/1/13/each-version-of-the-operating-system-is-correct-dotnet-support"
                },
                new()
                {
                    Title = ".NET�����롢����������ԣ����ء��۸ġ�α�죩��һ���汾����",
                    Memo = "ʹ���߱��˶��ڴ��������ñ����ں��ṩ����Ϣ����ɵ��κ�ֱ�ӻ��ӵĺ������ʧ��ȫ�����Ρ����ںż����߶�����Щ������е��κ����Ρ������ɺ���������ге����Ρ�лл��",
                    Cover = "https://img1.dotnet9.com/2023/09/cover_08.png",
                    Url =
                        "https://blog.dotnet9.com/post/2023/9/26/simulate-scenarios-using-third-party-dotnet-libraries-for-debugging-interception-decompilation-and-compatibility-solutions-for-multiple-versions-of-one-library"
                }
            }
        };

        return baseInfo;
    }
}