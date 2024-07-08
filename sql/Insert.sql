USE [db01]
GO

CREATE PROCEDURE [dbo].[InsertCompanyData]
    @ReportDate NVARCHAR(7),
    @DataYearMonth NVARCHAR(5),
    @CompanyCode NVARCHAR(4),
    @CompanyName NVARCHAR(20),
    @Industry NVARCHAR(20),
    @MonthlyRevenue DECIMAL(18, 2),
    @PreviousMonthlyRevenue DECIMAL(18, 2),
    @LastYearMonthlyRevenue DECIMAL(18, 2),
    @MonthlyComparisonPercentage FLOAT,
    @LastYearComparisonPercentage FLOAT,
    @CumulativeRevenue DECIMAL(18, 2),
    @LastYearCumulativeRevenue DECIMAL(18, 2),
    @PreviousComparisonPercentage FLOAT,
    @Notes NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO [dbo].[CompanyData] (
            ReportDate,
            DataYearMonth,
            CompanyCode,
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
        )
        VALUES (
            @ReportDate,
            @DataYearMonth,
            @CompanyCode,
            @CompanyName,
            @Industry,
            @MonthlyRevenue,
            @PreviousMonthlyRevenue,
            @LastYearMonthlyRevenue,
            @MonthlyComparisonPercentage,
            @LastYearComparisonPercentage,
            @CumulativeRevenue,
            @LastYearCumulativeRevenue,
            @PreviousComparisonPercentage,
            @Notes
        );

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
