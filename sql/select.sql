USE [db01]
GO

CREATE PROCEDURE [dbo].[SelectCompanyData]
    @CompanyCode NVARCHAR(4)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT 
            ReportDate,
            DataYearMonth,
            CompanyName,
            Industry,
            MonthlyRevenue,
            PreviousMonthlyRevenue,
            LastYearMonthlyRevenue,
            MonthlyComparisonPercentage,
            LastYearComparisonPercentage,
            CumulativeRevenue,
            LastYearCumulativeRevenue,
            PreviousComparisonPercentage,
            Notes
        FROM [dbo].[CompanyData]
        WHERE CompanyCode = @CompanyCode;

    END TRY
    BEGIN CATCH
        -- Return the error message if an error occurs
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();
        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO
