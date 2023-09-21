using DataAccess;
using DataAccess.DataAccess;

namespace BusinessObject.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member member) => MemberDAO.Instance.RemoveMember(member);

        public IEnumerable<Member> GetAllMembers() => MemberDAO.Instance.GetMembers();

        public Member? GetMember(int id) => MemberDAO.Instance.GetMemberById(id);

        public Member? GetMemberByEmail(string Email) => MemberDAO.Instance.GetMemberByEmail(Email);

        public void InsertMember(Member member) => MemberDAO.Instance.AddMember(member);

        public Member? LoginCheck(string email, string password) => MemberDAO.Instance.LoginCheck(email,password);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
    }
}
