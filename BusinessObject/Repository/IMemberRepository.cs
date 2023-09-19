using DataAccess.DataAccess;

namespace BusinessObject.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
        Member GetMember(int id);
        bool LoginCheck(Member member);
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
    }
}
