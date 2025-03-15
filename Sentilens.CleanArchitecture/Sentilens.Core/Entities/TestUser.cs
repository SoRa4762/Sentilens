using System.ComponentModel.DataAnnotations.Schema;

namespace Sentilens.Core.Entities;
[Table("TestUsers")]
public class TestUser
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
}