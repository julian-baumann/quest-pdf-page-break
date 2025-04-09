using QuestPDF;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPdfPageBreak;

Settings.License = LicenseType.Community;
Settings.EnableDebugging = true;
Settings.CheckIfAllTextGlyphsAreAvailable = false;

var document = Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(10, Unit.Millimetre);
        page.MarginBottom(3, Unit.Millimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(9));

        page.Header()
            .ShowOnce()
            .Element(Layout.ComposeHeader);

        page.Content()
            .Element(Layout.ComposeContent);

        page.Footer()
            .Element(Layout.ComposeFooter);
    });
});

// using var resultMemoryStream = File.OpenWrite("./Test.pdf");
// document.GeneratePdf(resultMemoryStream);

document.ShowInCompanion();