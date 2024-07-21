# 产品介绍

## MASA TSC是什么？

故障排查中心是 MASA Stack 1.0 中一个核心产品，主要负责对 MASA 整个系统中的项目/应用进行监测来排查故障情况，其中包含从项目维度视角来查看监测的故障情况。以及溯源到具体的链路日志中去。产品功能如：

![功能结构图](https://cdn.masastack.com/stack/doc/tsc/introduce/functional-structure.svg)

## 项目监测

通过项目维度对项目运行日志记录进行监测，反馈项目运行的状态。正常、告警、错误三种状态。可以选中时间范围查看项目运行时间过程中是否存在问题。同时接入Auth中的项目团队，确认用户所在团队后可以限制查看权限对应的项目团队中的项目。

## 项目应用指标可视化

通过项目监测可以查看项目中应用的情况，目前有一个基础查看模板。其中包含了应用程序的部分指标来反馈该项目中的应用程序情况，当然也可以查看应用的全部指标。可以根据需求选中时间的刷新频率来进行查看，同时可以切换项目中的其他应用查看，便于排查和分析故障原因。如果日志已经存在一定错误会有提示栏报出来。

## 日志查询

日志查询暂时没有支持项目团队的区分，在这里都可以查询所有已经监测的项目应用的记录，包括TSC本身的查询记录。搜索查询支持cron表达式条件搜索。暂不支持导出日志的功能。

## 追踪查询

追踪主要用于查询问题所发生的上下游关联数据，给与排查故障问题的数据参考。通过追踪查询可以了解到服务、接口等span数量以及耗时的时间。以及具体日志发生的情况。

## 特性与优势

1. 产品设计参考市面上常见监测性软件，在指标设置这一块有部分统一标准让用户通俗易懂；
2. 可以根据自己的需求配置所需要监测的应用指标和所需要展示的仪表盘；
3. 可以通过完整的链路追踪查看到具体故障来源和日志详情；
4. 配合Alert、MC可以将出现故障的可能性和可能造成的损失降低到最小。