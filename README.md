# MigraDocLite

A stripped down version of PdfSharp and Migradoc compatible with .net standard 2.1.


## Added features

Includes a hosted font resolver to assist with rendering unicode characters in multiple languages.

```
GlobalFontSettings.FontResolver = new HostedFontResolver();
var document = new Document();
document.Styles[StyleNames.Normal].Font.Name = HostedFontResolver.ArialUnicodeMs;
var section = document.AddSection();
section.AddParagraph("嗨雾账单");
var renderer = new PdfDocumentRenderer(true) { Document = document };
renderer.RenderDocument();
renderer.PdfDocument.Save("c:\\temp\\test.pdf");
```
