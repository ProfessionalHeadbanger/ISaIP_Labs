// Вариант 4
// k1 = 2 3 1 4 5
// k2 = 4 2 3 5 1

#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <Windows.h>

class DoubleTranspositionCipher {
public:
    DoubleTranspositionCipher(int rows, int cols, const std::vector<int> key1, const std::vector<int> key2)
        : rows(rows), cols(cols), key1(key1), key2(key2) {}

    std::string encrypt(const std::string text) 
    {
        std::vector<std::string> matrix = fillMatrix(text);

        std::vector<std::string> column_transposed_matrix = matrix;
        for (int j = 0; j < cols; j++) 
        {
            int col = key1[j] - 1;
            for (int i = 0; i < rows; i++) 
            {
                column_transposed_matrix[i][j] = matrix[i][col];
            }
        }

        std::vector<std::string> row_transposed_matrix(rows, std::string(cols, ' '));
        for (int i = 0; i < rows; i++) 
        {
            int row = key2[i] - 1;
            row_transposed_matrix[i] = column_transposed_matrix[row];
        }

        std::string ciphertext;
        for (int j = 0; j < cols; j++) 
        {
            for (int i = 0; i < rows; i++) 
            {
                ciphertext += row_transposed_matrix[i][j];
            }
        }

        return ciphertext;
    }

    std::string decrypt(const std::string ciphertext) 
    {
        std::vector<std::string> matrix = fillMatrix(ciphertext);

        std::vector<std::string> column_restored_matrix = matrix;
        for (int j = 0; j < cols; j++) 
        {
            int original_col = key2[j] - 1;
            for (int i = 0; i < rows; i++) 
            {
                column_restored_matrix[i][original_col] = matrix[i][j];
            }
        }

        std::vector<std::string> row_restored_matrix(rows, std::string(cols, ' '));
        for (int i = 0; i < rows; i++) {
            int original_row = key1[i] - 1;
            row_restored_matrix[original_row] = column_restored_matrix[i];
        }

        std::string plaintext;
        for (int j = 0; j < cols; j++) 
        {
            for (int i = 0; i < rows; i++) 
            {
                plaintext += row_restored_matrix[i][j];
            }
        }

        return plaintext;
    }

private:
    int rows, cols;
    std::vector<int> key1, key2;

    std::vector<std::string> fillMatrix(const std::string text)
    {
        std::vector<std::string> matrix(rows, std::string(cols, ' '));
        int index = 0;
        for (int i = 0; i < rows && index < text.size(); i++)
        {
            for (int j = 0; j < cols && index < text.size(); j++)
            {
                matrix[i][j] = text[index];
                index++;
            }
        }
        return matrix;
    }
};

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    int rows, cols;
    std::string text;
    std::vector<int> key1, key2;

    std::cout << "Введите количество строк матрицы: ";
    std::cin >> rows;
    std::cout << "Введите количество столбцов матрицы: ";
    std::cin >> cols;
    std::cin.ignore();

    std::cout << "Введите открытый текст: ";
    std::getline(std::cin, text);

    std::cout << "Введите ключ k1 для столбцов (через пробел, размер " << cols << "): ";
    key1.resize(cols);
    for (int i = 0; i < cols; i++) 
    {
        std::cin >> key1[i];
    }

    std::cout << "Введите ключ k2 для строк (через пробел, размер " << rows << "): ";
    key2.resize(rows);
    for (int i = 0; i < rows; i++) 
    {
        std::cin >> key2[i];
    }

    DoubleTranspositionCipher cipher(rows, cols, key1, key2);

    std::string encrypted_text = cipher.encrypt(text);
    std::cout << "Зашифрованный текст: " << encrypted_text << std::endl;

    std::string decrypted_text = cipher.decrypt(encrypted_text);
    std::cout << "Расшифрованный текст: " << decrypted_text << std::endl;
}