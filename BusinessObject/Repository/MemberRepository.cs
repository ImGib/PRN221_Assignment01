using DataAccess;
using DataAccess.DataAccess;

namespace BusinessObject.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member member) => MemberDAO.Instance.RemoveMember(member);

        public IEnumerable<Member> GetAllMembers() => MemberDAO.Instance.GetMembers();

        public Member GetMember(int id) => MemberDAO.Instance.GetMemberById(id);

        public void InsertMember(Member member) => MemberDAO.Instance.AddMember(member);

        public bool LoginCheck(Member member) => MemberDAO.Instance.LoginCheck(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
    }
}
