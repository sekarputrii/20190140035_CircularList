using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190140035_Assignment5
{
   class Node
    {
        //creates Nodes for the circular nexted list
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        public void addNode()
        {
            int rollNo;
            string name;
            Console.Write("\nMasukkan Nomor Siswa : ");
            rollNo = Int32.Parse(Console.ReadLine());
            Console.Write("\nMasukkan Nama Siswa : ");
            name = Console.ReadLine();
            
            Node newNode = new Node();
            newNode.rollNumber = rollNo;
            newNode.name = name;
            Node previous, current;

            if (LAST == null)
            {
                LAST = newNode;
                newNode.next = LAST;
                return;
            }
            if (rollNo < LAST.next.rollNumber)
            {
                newNode.next = LAST.next;
                LAST.next = newNode;
                return;
            }
            if (rollNo <= LAST.rollNumber)
            {
                if (LAST != null && rollNo == LAST.rollNumber)
                {
                    Console.WriteLine("\nNomor Data Duplikat tidak diperbolehkan\n");
                    return;
                }
                current = LAST.next;
                previous = current;

                while (rollNo > current.rollNumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = newNode;
                newNode.next = current;
                return;
            }
            if (rollNo > LAST.rollNumber)
            {
                newNode.next = LAST.next;
                LAST.next = LAST = newNode;
                return;
            }
        }
        //Searches for the specified node
        public bool Search (int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    //returns true if the node is found
                    return (true);
            }
            //if the node is present at the end
            if (rollNo == LAST.rollNumber)
                return true;
            else
                //return false if the node is not found
                return (false);
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        //traverse all the nodes of the list
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData yang Dicari Tidak Ada");
            else
            {
                Console.WriteLine("\nDaftar Data : \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + " ");
                    currentNode = currentNode.next;
                }
                Console.WriteLine(LAST.rollNumber + " " + LAST.name + " ");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nData yang Dicari Tidak Ada");
            else
                Console.WriteLine("\nYang Pertama dalam Daftar : \n\n" + LAST.next.rollNumber + " " + LAST.next.name);
        }
        //Delete the spesific node
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
            {
                return false;
            }
            //if the beginning node to be deleted
            if (rollNo == LAST.next.rollNumber) ;
            {
                current = LAST.next;
                LAST.next = current.next;
                return true;
            }
            //if the last node to be deleted
            if (rollNo == LAST.rollNumber)
            {
                current = LAST;
                previous = current.next;
                while (previous.next != LAST)
                {
                    previous = previous.next;
                }
                previous.next = LAST.next;
                LAST = previous;
                return true;
            }
            if (rollNo <= LAST.rollNumber)
            {
                current = previous = LAST.next;
                while (rollNo > current.rollNumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = current.next;
            }
            return true;
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-------------------------------------------");
                    Console.WriteLine("                  Menu");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("1. Masukkan Data");
                    Console.WriteLine("2. Tampilkan seluruh Data");
                    Console.WriteLine("3. Mencari Data");
                    Console.WriteLine("4. Tampilkan Data Pertama");
                    Console.WriteLine("5. Hapus Data");
                    Console.WriteLine("6. Keluar");
                    Console.Write("\nMasukkan Pilihan (1 - 6) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nData Yang Dicari Tidak Ada");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkann Nomor yang akan dicari : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData Tidak Ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData Ditemukan");
                                    Console.WriteLine("Nomor  : " + curr.rollNumber);
                                    Console.WriteLine("Nama : " + curr.name);
                                }
                            }
                            break;
                        case '4':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nData yang Dicari Tidak Ada");
                                    break;
                                }
                                Console.Write("\nMasukkan Nomor Siswa yang Akan Dihapus : ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Data Tidak Ditemukan");
                                else
                                    Console.WriteLine("Data pada Daftar " + rollNo + " Dihapus\n");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Opsi Tidak Valid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
