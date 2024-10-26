// Вариант 4
// p = 11
// q = 7
// EARTH

#include <iostream>
#include <vector>
#include <cmath>
#include <string>
#include <Windows.h>

class RSA
{
public:
    RSA(int p, int q) : p(p), q(q)
    {
        n = p * q;
        phi_n = (p - 1) * (q - 1);
        e = 2;
        while (e < phi_n && gcd(e, phi_n) != 1) 
        {
            e++;
        }
        d = modInverse(e, phi_n);
        if (d == -1) {
            throw std::runtime_error("Не удалось найти обратное число для e по модулю φ(n).");
        }
        open_key = {e, n};
        closed_key = {d, n};
    }

    void print()
    {
        std::cout << "phi(n): " << phi_n << std::endl;
        std::cout << "Открытый ключ: {" << open_key.first << ", " << open_key.second << "}\n";
        std::cout << "Закрытый ключ: {" << closed_key.first << ", " << closed_key.second << "}\n";
    }

    std::vector<int> encrypt(std::string message)
    {
        std::vector<int> encryptedMessage;
        for (char ch : message) 
        {
            int M = static_cast<int>(ch);
            int C = modPow(M, e, n);
            encryptedMessage.push_back(C);
        }
        return encryptedMessage;
    }

    std::string decrypt(std::vector<int> encryptedMessage)
    {
        std::string decryptedMessage;
        for (int C : encryptedMessage) 
        {
            int M = modPow(C, d, n);
            decryptedMessage += static_cast<char>(M);
        }
        return decryptedMessage;
    }
private:
    int p;
    int q;
    int n;
    int phi_n;
    int e;
    int d;
    std::pair<int, int> open_key;
    std::pair<int, int> closed_key;

    int gcd(int a, int b) 
    {
        while (b != 0) 
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    int modInverse(int e, int phi) {
        for (int d = 1; d < phi; ++d) {
            if ((e * d) % phi == 1) {
                return d;
            }
        }
        return -1;
    }

    int modPow(int base, int exp, int mod) {
        int result = 1;
        while (exp > 0) {
            if (exp % 2 == 1) {
                result = (result * base) % mod;
            }
            base = (base * base) % mod;
            exp /= 2;
        }
        return result;
    }
};

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    try {
        int p = 13;
        int q = 7;

        RSA cipher(p, q);
        cipher.print();

        std::string message;
        std::cout << "Введите сообщение для шифрования: ";
        std::getline(std::cin, message);

        std::vector<int> encryptedMessage = cipher.encrypt(message);
        std::cout << "Зашифрованное сообщение: ";
        for (int C : encryptedMessage) {
            std::cout << C << " ";
        }
        std::cout << std::endl;

        std::string decryptedMessage = cipher.decrypt(encryptedMessage);
        std::cout << "Расшифрованное сообщение: " << decryptedMessage << std::endl;

    }
    catch (const std::runtime_error& e) {
        std::cerr << e.what() << std::endl;
        return 1;
    }
}
