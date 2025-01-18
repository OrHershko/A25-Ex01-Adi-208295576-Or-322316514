using System.ComponentModel;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class PostProxy : INotifyPropertyChanged
    {
        private readonly Post r_Post;
        private string m_Description;

        public PostProxy(Post i_Post)
        {
            r_Post = i_Post;
            m_Description = r_Post.Description;
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

        public Post WrappedPost => r_Post;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string i_PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(i_PropertyName));
        }
    }

}