namespace FubuMVC.Diagnostics.Runtime
{
    public class RedirectReport
    {
        public string Url;

        public bool Equals(RedirectReport other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Url, Url);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (RedirectReport)) return false;
            return Equals((RedirectReport) obj);
        }

        public override int GetHashCode()
        {
            return (Url != null ? Url.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return string.Format("Url: {0}", Url);
        }
    }
}