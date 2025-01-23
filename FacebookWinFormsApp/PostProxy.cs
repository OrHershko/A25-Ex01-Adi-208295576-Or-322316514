using System.ComponentModel;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class PostProxy : INotifyPropertyChanged
    {
        public Post Post { get; }
        private string m_Description;
        public event PropertyChangedEventHandler PropertyChanged;

        public PostProxy(Post i_Post)
        {
            Post = i_Post;
            m_Description = Post.Description;
        }

        public string Description
        {
            get => m_Description;
            set
            {
                if(m_Description != value)
                {
                    m_Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        protected virtual void OnPropertyChanged(string i_PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(i_PropertyName));
        }
    }
}