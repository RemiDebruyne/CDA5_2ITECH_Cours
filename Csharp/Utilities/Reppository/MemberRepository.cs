using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entity;

namespace Utilities.Reppository;

public class MemberRepository : BaseRepository<Member>
{
    private LoanRepository _loanRepository = new();
    public Member? GetMemberByIdWithLoan(int id)
    {
        Member? member = GetById(id);

        if(member is null)
        {
            return null;
        }

        member.Loans = _loanRepository.GetByClientId(id);

        return member;
    }
}
