using HexagonalSendMail.Core.Application.Interfaces;
using HexagonalSendMail.Core.Application.Operations;
using HexagonalSendMail.Ports.SendMailWorker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ISendMail, SendMail>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
