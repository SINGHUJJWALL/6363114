using System;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Concrete factory for creating Excel documents
    /// Implements the Factory Method Pattern for Excel document creation
    /// </summary>
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            Console.WriteLine("🏭 ExcelDocumentFactory: Creating new Excel document...");
            Console.WriteLine("   Initializing Microsoft Excel spreadsheet structure");
            Console.WriteLine("   Setting up calculation engine and worksheet grid");

            return new ExcelDocument();
        }

        public override string GetFactoryInfo()
        {
            return "Excel Document Factory - Creates Microsoft Excel (.xlsx) spreadsheets with calculation capabilities";
        }
    }
}
