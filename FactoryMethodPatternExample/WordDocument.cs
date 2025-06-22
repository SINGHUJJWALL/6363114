using System;
using System.Collections.Generic;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Concrete implementation for Microsoft Word documents
    /// </summary>
    public class WordDocument : IDocument
    {
        private string _fileName;
        private List<string> _content;
        private bool _isOpen;
        private DateTime _createdAt;
        private DateTime _lastModified;

        public WordDocument()
        {
            _fileName = $"Document_{DateTime.Now:yyyyMMdd_HHmmss}.docx";
            _content = new List<string>();
            _isOpen = false;
            _createdAt = DateTime.Now;
            _lastModified = DateTime.Now;
        }

        public void Open()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                Console.WriteLine($"📄 Opening Word document: {_fileName}");
                Console.WriteLine("   Microsoft Word application launched");
                Console.WriteLine("   Document loaded with rich text formatting support");
            }
            else
            {
                Console.WriteLine($"⚠️  Word document {_fileName} is already open");
            }
        }

        public void Save()
        {
            if (_isOpen)
            {
                _lastModified = DateTime.Now;
                Console.WriteLine($"💾 Saving Word document: {_fileName}");
                Console.WriteLine("   Applying spell check and grammar corrections");
                Console.WriteLine("   Saving with .docx format compression");
                Console.WriteLine("   ✅ Word document saved successfully");
            }
            else
            {
                Console.WriteLine("❌ Cannot save: Word document is not open");
            }
        }

        public void Close()
        {
            if (_isOpen)
            {
                _isOpen = false;
                Console.WriteLine($"🔒 Closing Word document: {_fileName}");
                Console.WriteLine("   Releasing Microsoft Word resources");
            }
            else
            {
                Console.WriteLine("ℹ️  Word document is already closed");
            }
        }

        public string GetDocumentType()
        {
            return "Microsoft Word Document";
        }

        public string GetFileExtension()
        {
            return ".docx";
        }

        public void AddContent(string content)
        {
            _content.Add(content);
            _lastModified = DateTime.Now;
            Console.WriteLine($"✏️  Added text content to Word document: \"{content}\"");
            Console.WriteLine("   Applied default Word formatting styles");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("📋 WORD DOCUMENT INFORMATION");
            Console.WriteLine("─────────────────────────────");
            Console.WriteLine($"   File Name: {_fileName}");
            Console.WriteLine($"   Document Type: {GetDocumentType()}");
            Console.WriteLine($"   File Extension: {GetFileExtension()}");
            Console.WriteLine($"   Status: {(_isOpen ? "Open" : "Closed")}");
            Console.WriteLine($"   Created: {_createdAt:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"   Last Modified: {_lastModified:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"   Content Lines: {_content.Count}");

            if (_content.Count > 0)
            {
                Console.WriteLine("   Content Preview:");
                for (int i = 0; i < Math.Min(_content.Count, 3); i++)
                {
                    Console.WriteLine($"     • {_content[i]}");
                }
            }
        }
    }
}
