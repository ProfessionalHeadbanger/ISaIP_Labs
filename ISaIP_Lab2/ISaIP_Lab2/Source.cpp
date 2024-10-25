// ������� 4
// key = EARTH

#include <iostream>
#include <string>
#include <Windows.h>

class VigenereCipher
{
public:
    VigenereCipher(int capacity, std::string key) : capacity(capacity), key(key) {}

    std::string encrypt(const std::string& text)
    {
        std::string encryptedText;
        for (size_t i = 0; i < text.length(); i++)
        {
            char letter = toupper(text[i]);
            char keyLetter = toupper(key[i % key.length()]);

            if (isalpha(letter))
            {
                char encryptedChar = (letter + keyLetter - 2 * 'A') % 26 + 'A';
                encryptedText += encryptedChar;
            }
            else
            {
                encryptedText += letter;
            }
        }
        return encryptedText;
    }

    std::string decrypt(const std::string& encryptedText)
    {
        std::string decryptedText;
        for (size_t i = 0; i < encryptedText.length(); i++)
        {
            char letter = toupper(encryptedText[i]);
            char keyLetter = toupper(key[i % key.length()]);

            if (isalpha(letter))
            {
                char decryptedChar = (letter + 26 - keyLetter) % 26 + 'A';
                decryptedText += decryptedChar;
            }
            else
            {
                decryptedText += letter;
            }
        }
        return decryptedText;
    }
private:
    int capacity;
    std::string key;
};

int main() 
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    int capacity = 26;
    std::string text, key;
    std::cout << "������� ����� ��� ����������: ";
    std::getline(std::cin, text);
    std::cout << "������� ����: ";
    std::getline(std::cin, key);

    VigenereCipher cipher(capacity, key);

    std::string encryptedText = cipher.encrypt(text);
    std::cout << "������������� �����: " << encryptedText << std::endl;

    std::string decryptedText = cipher.decrypt(encryptedText);
    std::cout << "�������������� �����: " << decryptedText << std::endl;
}