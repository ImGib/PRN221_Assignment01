using DataAccess.DataAccess;
namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        //GetById
        public Member? GetMemberById(int id)
        {
            Member? member = null;
            try
            {
                var salesManage = new SalesManagementContext();
                member = salesManage.Members.SingleOrDefault(member => member.MemberId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public Member? GetMemberByEmail(string email)
        {
            Member? member = null;
            try
            {
                var salesManage = new SalesManagementContext();
                member = salesManage.Members.SingleOrDefault(member => member.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public Member? LoginCheck(string email, string password) {
            Member member = null;
            try
            {
                var salesManage = new SalesManagementContext();
                member = salesManage.Members.SingleOrDefault(mem => (mem.Email.Equals(email)) && (mem.Password.Equals(password)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        //GetAll
        public IEnumerable<Member> GetMembers()
        {
            List<Member> members = new List<Member>();
            try
            {
                var salesManage = new SalesManagementContext();
                members = salesManage.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return members;
        }
        //Insert
        public void AddMember(Member member)
        {
            try
            {
                //check exist
                Member? mem = GetMemberById(member.MemberId);
                if (mem == null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Members.Add(member);
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Member already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        //Update
        public void UpdateMember(Member member)
        {
            try
            {
                //check exist
                Member? mem = GetMemberById(member.MemberId);
                if (mem != null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Entry<Member>(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Member does not already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Member does not already exist!");
            }
        }
        //Delete
        public void RemoveMember(Member member)
        {
            try
            {
                //check exist
                Member? mem = GetMemberById(member.MemberId);
                if (mem != null)
                {
                    var salesManage = new SalesManagementContext();
                    salesManage.Members.Remove(member);
                    salesManage.SaveChanges();
                }
                else
                {
                    throw new Exception("Member does not already exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Member does not already exist!");
            }
        }
    }

}
