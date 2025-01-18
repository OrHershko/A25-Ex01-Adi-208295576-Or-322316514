using System.ComponentModel;
using FacebookWrapper.ObjectModel;

public class PostProxy : INotifyPropertyChanged
{
    private readonly Post m_Post;
    private string m_Description;

    public PostProxy(Post i_Post)
    {
        m_Post = i_Post;
        m_Description = m_Post.Description;
    }

    public string Description
    {
        get => m_Description;
        set
        {
            if (m_Description != value)
            {
                m_Description = value; 
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    public Post WrappedPost => m_Post;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string i_PropertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(i_PropertyName));
    }
}