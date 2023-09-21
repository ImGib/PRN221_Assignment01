using DataAccess.DataAccess;

namespace BusinessObject.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
        Member? GetMember(int id);
        Member? GetMemberByEmail(string Email);
        public Member? LoginCheck(string email, string password);
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
    }
}
