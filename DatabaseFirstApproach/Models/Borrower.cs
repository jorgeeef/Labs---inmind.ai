using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach.Models;

public partial class Borrower
{
    public int BorrowerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
