using System;
using System.Collections.Generic;

namespace FactoryMethodPatternExample
{
    /// <summary>
    /// Concrete implementation for PDF documents
    /// </summary>
    public class PdfDocument : IDocument
    {
        private string _fileName;
        private List<string> _pages;
        private bool _isOpen;
        private DateTime _createdAt;
        private DateTime _lastModified;
        private bool _isPasswordProtected;

        public PdfDocument()
        {
            _fileName = $"Document_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            _pages = new List<string>();
            _isOpen = false;
            _createdAt = DateTime.Now;
            _lastModified = DateTime.Now;
            _isPasswordProtected = false;
        }

        public void Open()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                Console.WriteLine($"📕 Opening PDF document: {_fileName}");
                Console.WriteLine("   Adobe PDF Reader initialized");
                Console.WriteLine("   Loading portable document format");
                Console.WriteLine("   Document ready for viewing (read-only mode)");
            }
            else
            {
                Console.WriteLine($"⚠️  PDF document {_fileName} is already open");
            }
        }

        public void Save()
        {
            if (_isOpen)
            {
                _lastModified = DateTime.Now;
                Console.WriteLine($"💾 Saving PDF document: {_fileName}");
                Console.WriteLine("   Optimizing PDF structure");
                Console.WriteLine("   Compressing images and fonts");
                Console.WriteLine("   Applying PDF/A compliance standards");
                Console.WriteLine("   ✅ PDF document saved successfully");
            }
            else
            {
                Console.WriteLine("❌ Cannot save: PDF document is not open");
            }
        }

        public void Close()
        {
            if (_isOpen)
            {
                _isOpen = false;
                Console.WriteLine($"🔒 Closing PDF document: {_fileName}");
                Console.WriteLine("   Releasing PDF reader resources");
            }
            else
            {
                Console.WriteLine("ℹ️  PDF document is already closed");
            }
        }

        public string GetDocumentType()
        {
            return "Portable Document Format";
        }

        public string GetFileExtension()
        {
            return ".pdf";
        }

        public void AddContent(string content)
        {
            _pages.Add(content);
            _lastModified = DateTime.Now;
            Console.WriteLine($"📄 Added new page to PDF document: \"{content}\"");
            Console.WriteLine("   Applied PDF formatting and layout");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("📋 PDF DOCUMENT INFORMATION");
            Console.WriteLine("────────────────────────────");
            Console.WriteLine($"   File Name: {_fileName}");
            Console.WriteLine($"   Document Type: {GetDocumentType()}");
            Console.WriteLine($"   File Extension: {GetFileExtension()}");
            Console.WriteLine($"   Status: {(_isOpen ? "Open" : "Closed")}");
            Console.WriteLine($"   Password Protected: {(_isPasswordProtected ? "Yes" : "No")}");
            Console.WriteLine($"   Created: {_createdAt:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"   Last Modified: {_lastModified:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"   Total Pages: {_pages.Count}");

            if (_pages.Count > 0)
            {
                Console.WriteLine("   Page Preview:");
                for (int i = 0; i < Math.Min(_pages.Count, 2); i++)
                {
                    Console.WriteLine($"     Page {i + 1}: {_pages[i]}");
                }
            }
        }

        public void SetPasswordProtection(bool enabled)
        {
            _isPasswordProtected = enabled;
            Console.WriteLine($"🔐 PDF password protection: {(enabled ? "Enabled" : "Disabled")}");
        }
    }
}
