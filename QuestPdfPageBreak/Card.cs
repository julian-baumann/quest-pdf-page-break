using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPdfPageBreak;

public static class CardExtensions
{
    public static void PrimaryCard(this IContainer container, string? title, Action<IContainer> contentDelegate)
    {
        Card(
            container,
            true,
            title,
            17,
            Colors.Cyan.Darken4,
            3,
            contentDelegate
        );
    }
    
    public static void Card(this IContainer container, bool renderBorder, string? title, float titleSize, string headerColor, float headerPadding, Action<IContainer> contentDelegate)
    {
        container
            .Layers(layers =>
            {
                if (title == null)
                {
                    contentDelegate.Invoke(layers.PrimaryLayer());   
                }
                else
                {
                    layers.PrimaryLayer()
                    .Decoration(decoration =>
                    {
                        decoration.Before()
                            .ExtendHorizontal()
                            .Layers(headerLayers =>
                            {
                                headerLayers.PrimaryLayer()
                                    .BorderColor(Colors.Grey.Lighten2)
                                    .BorderBottom(1)
                                    .Padding(headerPadding)
                                    .Text(title)
                                    .FontColor(headerColor)
                                    .FontSize(titleSize)
                                    .Bold();
                            });

                        contentDelegate.Invoke(decoration.Content().Padding(2).PaddingHorizontal(2));
                    });
                }
                
                if (renderBorder)
                {
                    layers.Layer().SkiaSharpCanvas((canvas, size) =>
                    {
                        canvas.DrawRoundedBorder(size, 3, Colors.Grey.Lighten2);
                    });   
                }
            });
    }
}