namespace Identificators
{
    public class BinTree <T>
    {
        public BinTree<T> right { get; private set; } = null;
        public BinTree<T> left { get; private set; } = null;

        public T data;

        public BinTree (T data)
        {
            this.data = data;
        }
        public BinTree(T data, BinTree<T> right, BinTree<T> left): this(data)
        {
            this.right = right;
            this.left = left;
        }
        public BinTree(BinTree<T> left, T data): this(data, null, left) { }
        public BinTree(T data, BinTree<T> right): this(data, right, null) { }


        public void NewRight(T data)
        {
            right = new BinTree<T>(data);
        }
        public void NewLeft(T data)
        {
            left = new BinTree<T>(data);
        }
    }
}