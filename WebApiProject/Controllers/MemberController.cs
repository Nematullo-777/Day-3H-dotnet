using System;
using Domain.Entities;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MembersController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpGet]
    public IActionResult GetAllMembers()
    {
        return Ok(_memberService.GetAllMembersAsync());
    }

    [HttpGet("{id}")]
    public IActionResult GetMemberById(int id)
    {
        var member = _memberService.GetMemberByIdAsync(id);

        if (member == null)
            return NotFound();

        return Ok(member);
    }

    [HttpPost]
    public IActionResult AddMember([FromBody] Member member)
    {
        _memberService.AddMemberAsync(member);
        return Ok("Member created");
    }

    [HttpPut]
    public IActionResult UpdateMember([FromBody] Member member)
    {
        _memberService.UpdateMemberAsync(member);
        return Ok("Member updated");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMember(int id)
    {
        _memberService.DeleteMemberAsync(id);
        return Ok("Member deleted");
    }
}