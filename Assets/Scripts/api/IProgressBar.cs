namespace api
{
    public interface IProgressBar
    {
        void reset();

        void setMaximum(int maxSeconds);

        void incrementSelection();
    }
}
