using System;
using System.Collections.Generic;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Concrete implementation for Microsoft Excel documents
    /// </summary>
    public class ExcelDocument : IDocument
    {
        private string _fileName;
        private Dictionary<string, List<string>> _worksheets;
        private bool _isOpen;
        private DateTime _createdAt;
        private DateTime _lastModified;
        private string _activeWorksheet;

        public ExcelDocument()
        {
            _fileName = $"Workbook_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            _worksheets = new Dictionary<string, List<string>>();
            _isOpen = false;
            _createdAt = DateTime.Now;
            _lastModified = DateTime.Now;
            _activeWorksheet = "Sheet1";

            // Initialize with default worksheet
            _worksheets.Add(_activeWorksheet, new List<string>());
        }

        public void Open()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                Console.WriteLine($"📊 Opening Excel document: {_fileName}");
                Console.WriteLine("   Microsoft Excel application launched");
                Console.WriteLine("   Loading spreadsheet with calculation engine");
                Console.WriteLine("   Worksheets and formulas ready for editing");
            }
            else
            {
                Console.WriteLine($"⚠️  Excel document {_fileName} is already open");
            }
        }

        public void Save()
        {
            if (_isOpen)
            {
                _lastModified = DateTime.Now;
                Console.WriteLine($"💾 Saving Excel document: {_fileName}");
                Console.WriteLine("   Recalculating all formulas and pivot tables");
                Console.WriteLine("   Saving with .xlsx format compression");
                Console.WriteLine("   Updating chart data and references");
                Console.WriteLine("   ✅ Excel document saved successfully");
            }
            else
            {
                Console.WriteLine("❌ Cannot save: Excel document is not open");
            }
        }

        public void Close()
        {
            if (_isOpen)
            {
                _isOpen = false;
                Console.WriteLine($"🔒 Closing Excel document: {_fileName}");
                Console.WriteLine("   Releasing Microsoft Excel resources");
            }
            else
            {
                Console.WriteLine("ℹ️  Excel document is already closed");
            }
        }

        public string GetDocumentType()
        {
            return "Microsoft Excel Spreadsheet";
        }

        public string GetFileExtension()
        {
            return ".xlsx";
        }

        public void AddContent(string content)
        {
            if (_worksheets.ContainsKey(_activeWorksheet))
            {
                _worksheets[_activeWorksheet].Add(content);
                _lastModified = DateTime.Now;
                Console.WriteLine($"📝 Added data to Excel worksheet '{_activeWorksheet}': \"{content}\"");
                Console.WriteLine("   Applied Excel cell formatting and data validation");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("📋 EXCEL DOCUMENT INFORMATION");
            Console.WriteLine("──────────────────────────────");
            Console.WriteLine($"   File Name: {_fileName}");
            Console.WriteLine($"   Document Type: {GetDocumentType()}");
            Console.WriteLine($"   File Extension: {GetFileExtension()}");
            Console.WriteLine($"   Status: {(_isOpen ? "Open" : "Closed")}");
            Console.WriteLine($"   Active Worksheet: {_activeWorksheet}");
            Console.WriteLine($"   Created: {_createdAt:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"   Last Modified: {_lastModified:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"   Total Worksheets: {_worksheets.Count}");

            foreach (var worksheet in _worksheets)
            {
                Console.WriteLine($"   Worksheet '{worksheet.Key}': {worksheet.Value.Count} entries");
                if (worksheet.Value.Count > 0)
                {
                    for (int i = 0; i < Math.Min(worksheet.Value.Count, 2); i++)
                    {
                        Console.WriteLine($"     Row {i + 1}: {worksheet.Value[i]}");
                    }
                }
            }
        }

        public void AddWorksheet(string worksheetName)
        {
            if (!_worksheets.ContainsKey(worksheetName))
            {
                _worksheets.Add(worksheetName, new List<string>());
                Console.WriteLine($"➕ Added new worksheet: '{worksheetName}'");
            }
            else
            {
                Console.WriteLine($"⚠️  Worksheet '{worksheetName}' already exists");
            }
        }

        public void SetActiveWorksheet(string worksheetName)
        {
            if (_worksheets.ContainsKey(worksheetName))
            {
                _activeWorksheet = worksheetName;
                Console.WriteLine($"📋 Active worksheet changed to: '{worksheetName}'");
            }
            else
            {
                Console.WriteLine($"❌ Worksheet '{worksheetName}' not found");
            }
        }
    }
}
