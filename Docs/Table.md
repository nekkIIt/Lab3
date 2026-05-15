# Таблиця проєктування тестів 

| Тест-кейс | Вхідні дані | Очікуваний результат | Техніка (EP/BVA) | Статус (pass/fail) |
| :--- | :--- | :--- | :--- | :--- |
| **ValidateAnswer_CorrectIndex** | `Options`=["A","B","C","D"], `Correct`=1, `index`=1 | `true` | EP (Позитивний) | pass |
| **ValidateAnswer_IncorrectIndex**| `Options`=["A","B","C","D"], `Correct`=1, `index`=3 | `false` | BVA (Верхня межа валідних) | pass |
| **ValidateAnswer_NegativeIndex** | `Options`=["A","B","C","D"], `index`=-1 | Виняток `ArgumentOutOfRangeException` | BVA (Нижче нуля) | pass |
| **ValidateAnswer_IndexOutOfRange**| `Options`=["A","B","C","D"], `index`=4 | Виняток `ArgumentOutOfRangeException` | BVA (Дорівнює `Count`) | pass |
| **ValidateAnswer_EmptyOptions** | `Options`=[] (Пустий список), `index`=1 | Виняток `InvalidOperationException` | BVA (Пусті дані) | pass |
| **CalculatePoints_InstantResponse**| `responseTime`=0.0, `timeLimit`=10.0 | `1000` | BVA (Мінімальний час) | pass |
| **CalculatePoints_LastSecond** | `responseTime`=10.0, `timeLimit`=10.0 | `500` | BVA (Максимальний час) | pass |
| **CalculatePoints_TimeExceeded** | `responseTime`=10.1, `timeLimit`=10.0 | `0` | BVA (Поза межами ліміту) | pass |
| **CalculatePoints_NegativeTime** | `responseTime`=-0.1, `timeLimit`=10.0 | Виняток `ArgumentException` | BVA (Негативний час) | pass |
| **CalculatePoints_NegativeLimit**| `responseTime`=5.0, `timeLimit`=0.0 | Виняток `ArgumentException` | BVA (Негативний ліміт) | pass |
| **CalculateFinalScore_ValidResults**| Список: `ScoreEarned`=[1000, 500] | `1500` | EP (Позитивний) | pass |
| **CalculateFinalScore_EmptyList**| Пустий список `results.Count`=0 | `0` | BVA (Мінімальна кількість) | pass |
| **CalculateFinalScore_NegativeScore**| Список: `ScoreEarned`=[1000, -10] | Виняток `InvalidOperationException` | EP (Негативний) | pass |
| **CalculateFinalScore_NullList** | Список `results` = null | Виняток `ArgumentNullException` | BVA (Відсутність об'єкта) | pass |