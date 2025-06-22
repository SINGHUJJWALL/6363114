using System;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Concrete factory for creating PDF documents
    /// Implements the Factory Method Pattern for PDF document creation
    /// </summary>
    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            Console.WriteLine("🏭 PdfDocumentFactory: Creating new PDF document...");
            Console.WriteLine("   Initializing Portable Document Format structure");
            Console.WriteLine("   Setting up cross-platform compatibility");

            return new PdfDocument();
        }

        public override string GetFactoryInfo()
        {
            return "PDF Document Factory - Creates Portable Document Format (.pdf) files for universal viewing";
        }
    }
}
