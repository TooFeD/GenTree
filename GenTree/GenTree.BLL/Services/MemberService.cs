using System.Collections.Generic;
using System.Runtime.InteropServices;
using GenTree.DAL;
using GenTree.SharedEntities.Models;

namespace GenTree.BLL.Services
{
    public class MemberService:ServiceBase
    {
        public MemberService(UnitOfWork uow) : base(uow)
        {
        }

        public void AddMember(string userId,Member member)
        {
            var treeId = Uow.TreeRepository.GetByUserId(userId).Id;
            member.TreeId = treeId;
            Uow.MemberRepository.Add(member);
        }

        public void CreateLinkChildParent(int childId,int parentId)
        {
            Childs child = new Childs()
            {
                ChildId = childId,
                MemberId = parentId
            };
            Uow.ChildsRepository.Add(child);
            Parents parent = new Parents()
            {
                MemberId = childId,
                ParentId = parentId
            };
            Uow.ParentsRepository.Add(parent);
        }

        public void CreateLinkMarriage(int member1Id, int member2Id)
        {
            Marriage marriage = new Marriage()
            {
                MemberId = member1Id,
                MarriagId = member2Id,
                IsMarriade = true
            };
            Uow.MarriageRepository.Add(marriage);
            Marriage marriage2 = new Marriage()
            {
                MemberId = member2Id,
                MarriagId = member1Id,
                IsMarriade = true
            };
            Uow.MarriageRepository.Add(marriage2);
        }

        public void ChangeMarriade(int memb1, int memb2, bool isMarriad)
        {
            var marriage1 = Uow.MarriageRepository.GetMarriageById(memb1, memb2);
            marriage1.IsMarriade = isMarriad;
            var marriage2 = Uow.MarriageRepository.GetMarriageById(memb2, memb1);
            marriage2.IsMarriade = isMarriad;
        }

        public List<Member> GetMemberByUserId(string userId)
        {
            return Uow.MemberRepository.GetMembersByUserId(userId);
        }

        public void ChangeMember(Member memb)
        {
            var member = Uow.MemberRepository.GetById(memb.Id);
            member.Address = memb.Address;
            member.DateOfBirth = memb.DateOfBirth;
            member.DateOfDeth = memb.DateOfDeth;
            member.FirstName = memb.FirstName;
            member.LastName = memb.LastName;
            member.OtherInfo = memb.OtherInfo;
        }

        public void AddDiseaseToMember(int diseaseId, int memberId)
        {
            HaveDiseases linkDisease = new HaveDiseases();
            linkDisease.MemberId = memberId;
            linkDisease.GenDiseasesId = diseaseId;
            linkDisease.Dominant = false;
            Uow.HaveDiseaseRepository.Add(linkDisease);
        }

        public void ChangeDiseaseInMember(int membId, int diseaseId, HaveDiseases disease)
        {
            HaveDiseases diseases = Uow.HaveDiseaseRepository.GetDiseaseByIdMember(membId, diseaseId);
            diseases.Dominant = disease.Dominant;
            diseases.GenDiseasesId = disease.GenDiseasesId;

        }
    }
}