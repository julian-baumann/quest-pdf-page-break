using QuestPDF.Infrastructure;
using SkiaSharp;

namespace QuestPdfPageBreak;

public static class CanvasExtensions
{
    public static void DrawRoundedBorder(this SKCanvas canvas, Size size, float radius, string color)
    {
        using var paint = new SKPaint();
        paint.Color = SKColor.Parse(color);
        paint.IsStroke = true;
        paint.StrokeWidth = 1;
        paint.IsAntialias = true;

        canvas.DrawRoundRect(0, 0, size.Width, size.Height, radius, radius, paint);
    }
    
    public static void DrawRoundedBox(this SKCanvas canvas, Size size, float radius, string color)
    {
        using var paint = new SKPaint();
        paint.Color = SKColor.Parse(color);
        paint.IsStroke = false;
        paint.StrokeWidth = 1;
        paint.IsAntialias = true;

        canvas.DrawRoundRect(0, 0, size.Width, size.Height, radius, radius, paint);
    }
}