﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("~~Центр генерации сертификатов~~\n");
                Console.WriteLine("1. Создать корневой сертификат");
                Console.WriteLine("2. Создать сертификат");
                Console.Write("Выберите подпрограмму (0 - завершение работы приложения): ");
                if (int.TryParse(Console.ReadLine(), out int no)) 
                {
                    switch (no)
                    {
                        case 0:
                            Console.WriteLine("Завершение работы приложения");
                            Console.ReadKey();
                            return;
                        case 1:
                            CertificateConfiguration certificateConfiguration = new CertificateConfiguration
                            {
                                CertName = "Биба и Боба CA",                              
                                OutFolder = @"D:\cert",
                                Password = "12345678",
                                Certduration = 30
                            };
                            CertificateGenerationProvider certificateGenerationProvider = new CertificateGenerationProvider();
                            certificateGenerationProvider.GenerateRootCertificate(certificateConfiguration);

                            break;
                        case 2:
                            int counter = 0;
                            CertificateExplorerProvider certificateExplorerProvider = new CertificateExplorerProvider(true);
                            certificateExplorerProvider.LoadCertificates();
                            foreach (var certificate in certificateExplorerProvider.Certificates)
                            {
                                Console.WriteLine($"{counter++} >>> {certificate}");
                            }
                            Console.Write("Укажите номер корневого сертификата");
                            CertificateConfiguration addCertificateConfiguration = new CertificateConfiguration
                            {
                                RootCertificate = certificateExplorerProvider.Certificates[int.Parse(Console.ReadLine())].X509Certificate2,
                                CertName = "IT Depart",
                                OutFolder = @"D:\cert",
                                Password = "12345678",
                                Certduration = 1
                            };
                            CertificateGenerationProvider certificateGenerationProvider2 = new CertificateGenerationProvider();
                            certificateGenerationProvider2.GenerateCertificate(addCertificateConfiguration);
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Некорректный номер подпрограммы. Пожалуйста, повторите ввод");
                            break;
                    }             
                }
                else
                    Console.WriteLine("Некорректный номер подпрограммы. Пожалуйста, повторите ввод");
            }
        }
    }
}
