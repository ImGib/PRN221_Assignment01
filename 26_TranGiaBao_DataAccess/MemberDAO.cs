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
        public Boolean LoginCheck(Member member) {
            try
            {
                var salesManage = new SalesManagementContext();
                Member? mem = salesManage.Members.SingleOrDefault(mem => (mem.Email.Equals(member.Email)) && (mem.Password.Equals(member.Password)));
                if(mem == null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
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
