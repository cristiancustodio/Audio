using MudBlazor;

namespace Web.Pages;

public partial class Audiometros
{
    public string GetDateStatus(DateTime date)
    {
        var daysDiff = (DateTime.Today - date).Days;
        return daysDiff switch
        {
            < 30 => "Recente",
            < 90 => $"Há {daysDiff} dias",
            < 365 => $"Há {daysDiff / 30} meses",
            _ => "Desatualizado"
        };
    }

    public Color GetDateStatusColor(DateTime date)
    {
        var daysDiff = (DateTime.Today - date).Days;
        return daysDiff switch
        {
            < 90 => Color.Success,
            < 365 => Color.Warning,
            _ => Color.Error
        };
    }

    private string GetOverallStatus(AudiometerModel audiometer)
    {
        if (!audiometer.CalibrationDate.HasValue && !audiometer.MeasurementDate.HasValue)
            return "Pendente Configuração";

        var oldestDate = new[] { audiometer.CalibrationDate, audiometer.MeasurementDate }
            .Where(d => d.HasValue)
            .Select(d => d.Value)
            .DefaultIfEmpty(DateTime.MinValue)
            .Min();

        if (oldestDate == DateTime.MinValue) return "Pendente";

        var daysDiff = (DateTime.Today - oldestDate).Days;
        return daysDiff switch
        {
            < 90 => "Em Dia",
            < 365 => "Atenção",
            _ => "Desatualizado"
        };
    }

    private Color GetOverallStatusColor(AudiometerModel audiometer)
    {
        var status = GetOverallStatus(audiometer);
        return status switch
        {
            "Em Dia" => Color.Success,
            "Atenção" => Color.Warning,
            "Desatualizado" => Color.Error,
            _ => Color.Secondary
        };
    }
}