namespace SteamB23.Consolar
{
    /// <summary>
    /// 콘솔화면에 표시하거나 지우는 메서드를 정의합니다.
    /// </summary>
    public interface IPresentable
    {
        /// <summary>
        /// 콘솔에 텍스트를 표시합니다.
        /// </summary>
        void Present();
        /// <summary>
        /// 표시했던 텍스트를 지웁니다.
        /// </summary>
        void Depresent();
    }
}
