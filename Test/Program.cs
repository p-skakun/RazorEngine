using System;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string template = "Hello @Model.Name, welcome to RazorEngine!";
            //var result = Engine.Razor.RunCompile(template, "templateKey", null, new { Name = "World" });
            using (var service = RazorEngineService.Create(new TemplateServiceConfiguration() { Debug = true })) {
                string parent = @"@RenderSection(""MySection"", false) test1";
                string section_test_1 = "@{ Layout = \"ParentLayout\"; }\n@section MySection { My section content }";
                var parentKey = service.GetKey("ParentLayout");
                service.AddTemplate(parentKey, parent);

                var result = service.RunCompile(section_test_1, nameof(section_test_1));
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
