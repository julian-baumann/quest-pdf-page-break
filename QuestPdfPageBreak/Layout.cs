using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPdfPageBreak;

public class Layout
{
    public static void ComposeHeader(IContainer container)
    {
        container
            .PaddingBottom(20)
            .Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("Test PDF")
                        .FontSize(25)
                        .LineHeight(0.6f)
                        .Bold();

                    column.Item()
                        .PaddingBottom(3)
                        .Text("Subtitle")
                        .FontSize(20)
                        .Bold()
                        .FontColor("#808080");
                });
            });
    }
    
    public static void ComposeFooter(IContainer container)
    {
        container
            .Row(row =>
            {
                row.RelativeItem()
                    .AlignLeft()
                    .Height(20)
                    .Width(65)
                    .Hyperlink("https://example.com/")
                    .Background(Colors.Grey.Lighten2);

                row.RelativeItem()
                    .AlignCenter()
                    .Text($"Some text");

                row.RelativeItem()
                    .AlignRight()
                    .Text(text =>
                    {
                        text.CurrentPageNumber();
                        text.Span("/");
                        text.TotalPages();
                    });
            });
    }

    public static void ComposeContent(IContainer container)
    {

        container.Column(column =>
        {
            column.Item()
                .PreventPageBreak()
                .Background(Colors.Green.Lighten2)
                .Height(500);
            
            column.Item()
                .PreventPageBreak()
                .Background(Colors.Blue.Lighten2)
                .PreventPageBreak()
                .Column(c =>
                {
                    c.Item()
                        .Height(300)
                        .Background(Colors.Cyan.Lighten2);
                    
                    c.Item()
                        .Height(500)
                        .Background(Colors.Cyan.Lighten2);
                });
        });
    }
}