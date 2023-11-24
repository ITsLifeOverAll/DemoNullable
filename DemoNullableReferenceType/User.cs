namespace DemoNullableReferenceType;

public class User
{
    public string UserId { get; set; } // 非 nullable，因為每個用戶都必須有一個唯一的識別碼。
    public string? Nickname { get; set; } // nullable，因為不是所有用戶都有昵稱。
    public string Email { get; set; } // 非 nullable，假設在我們的系統中，電子郵件是用戶註冊的必要條件。
    public DateTime DateOfBirth { get; set; } // 非 nullable，出生日期是必要信息。
    public string? ProfilePictureUrl { get; set; } // nullable，因為不是每個用戶都會設定個人頭像。

    public User(string userId, string email, DateTime dateOfBirth)
    {
        UserId = userId;
        Email = email;
        DateOfBirth = dateOfBirth;
    }

    public User()
    {
    }

    // 如果 class User 是由 DB 取得的, 那麼同時要考量 DB table 的欄位是否 nullable
}
