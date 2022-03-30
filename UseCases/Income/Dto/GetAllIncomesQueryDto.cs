using System;

namespace UseCases.Income.Dto
{
    public class GetAllIncomesQueryDto
    {
        public int[]? Accounts { get; set; }
        public double? AmountMin { get; set; }
        public double? AmountMax { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Comment { get; set; }
    }
}
