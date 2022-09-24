# Основы работы с Unity
Отчет по лабораторной работе #1 выполнила:
- Россихина Ирина Александровна
- РИ-300002

Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Задание 2.
- Задание 3.
- Выводы.

## Цель работы
Ознакомиться с основными функциями Unity и взаимодействием с объектами внутри редактора.

## Задание 1
### Пошагово выполнить каждый пункт раздела "ход работы" с описанием и примерами реализации задач по теме видео самостоятельной работы.
Ход работы:
1) Создать новый проект из шаблона 3D – Core.

![создание проекта](https://user-images.githubusercontent.com/74662720/191661608-48c85b9c-6d8a-4a62-9b10-b45989580638.png)

2) Проверить, что настроена интеграция редактора Unity и Visual Studio Code (пункты 8-10 введения).

![интеграция](https://user-images.githubusercontent.com/74662720/191661819-88199ddf-d95f-417c-b2e4-576e8cbef2fc.png)

3) Создать объект Plane.

![Plane](https://user-images.githubusercontent.com/74662720/191661996-23f171fd-4331-4c3f-83cb-a85a31e4ed67.png)

4) Таким же образом создаём объекты Cube и Sphere. Вот так они выглядят на сцене.

![все объекты](https://user-images.githubusercontent.com/74662720/191662587-a31d8010-3622-42a9-9aef-8709a62e8418.png)

5) Установить компонент Sphere Collider для объекта Sphere. Для этого у сферы в окне Inspector нажимаем на Add Component, а далее с помощью поиска находим необходимый компонент.

6) Настроить Sphere Collider в роли триггера.

![поставили trigger](https://user-images.githubusercontent.com/74662720/191663308-78d1689d-60fc-4f84-800d-cfebec4417cc.png)

7) Объект куб перекрасить в красный цвет.
Создаём в папке Assets новую сущность Material. В свойствах меняем цвет.

![задаём цвет](https://user-images.githubusercontent.com/74662720/191664320-0a4c8a24-b1c3-4486-9a73-90894bc39cf5.png)

Затем эту сущность мы можем применить на любой объект. Перекрасим куб. Замечание: если мы поменяем свойства сущности Material, то изменения отразятся на всех объектах, к которым мы применили эту сущность.

![куб теперь красный](https://user-images.githubusercontent.com/74662720/191664708-f61e9b01-89d6-44dd-b51e-cf89421e2fab.png)

8) Добавить кубу симуляцию физики, при этом куб не должен проваливаться под Plane. Для добавления физики нам нужно использовать компонент RigidBody. Устанавливаем его на объект Cube. Чтобы объект не проваливался под Plane, нужно включить свойство Is Kinematic и выключить свойство Use Gravity.

![+ физика - гравитация](https://user-images.githubusercontent.com/74662720/191665389-79ca47e8-ed26-49a0-bbd2-f788cdcdaa54.png)

9) Написать скрипт, который будет выводить в консоль сообщение о том, что объект Sphere столкнулся с объектом Cube. В окне Inspector объекта Sphere через Add Component создаём новый скрипт CheckCollider. В этом скрипте напишем метод OnTriggerEnter, который выводит сообщение в консоль при столкновении объектов.

        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class CheckCollider : MonoBehaviour
        {
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }

            private void OnTriggerEnter(Collider other)
            {
                Debug.Log("Произошло столкновение объекта Sphere с объектом " + other.gameObject.name);
            }
        }

Сохраняем скрипт. Проверяем, что у куба есть компонент RigidBody с включённым свойством Is Kinematic и выключенным свойством Use Gravity. Запускаем сцену и передвигаем сферу в куб. При столконовении объекта Sphere с объектом Cube в консоли возникает сообщение.

![произошло столкновение](https://user-images.githubusercontent.com/74662720/191670837-f38afde0-8e6f-46e0-ba1d-13b4bf73815e.png)

11) При столкновении Cube должен менять свой цвет на зелёный, а при завершении столкновения обратно на красный. Для этого модифицируем скрипт CheckCollider.

        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class CheckCollider : MonoBehaviour
        {
            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }

            private void OnTriggerEnter(Collider other)
            {
                Debug.Log("Произошло столкновение с " + other.gameObject.name);
                other.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }

            private void OnTriggerExit(Collider other)
            {
                Debug.Log("Завершено столкновение с " + other.gameObject.name);
                other.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
        }

Сохраняем скрипт и запускаем сцену. Сталкиваем сферу и куб.

![Screenshot_25](https://user-images.githubusercontent.com/74662720/191671883-11c5cfca-b317-4c13-900d-ec273b1ef70c.png)

Отодвигаем сферу от куба.

![Screenshot_26](https://user-images.githubusercontent.com/74662720/191671929-d9a2e8fe-545a-42c1-ab14-b3d69ad498c5.png)


## Задание 2
### Продемонстрируйте на сцене в Unity следующее:
### - Что произойдёт с координатами объекта, если он перестанет быть дочерним?
1) Пусть у объекта Plane будет дочерний объект Cylinder

![plane and cyl](https://user-images.githubusercontent.com/74662720/192109696-01791223-0eec-4d5c-b8c9-373f5c65b6dc.png)

2) Передвинем Plane по оси X. Координаты Plane изменились.

![сдвинули плоскоть её коорты](https://user-images.githubusercontent.com/74662720/192109738-4492d032-3135-4408-8b99-fbd22e5ee782.png)

А у Cylinder координаты прежние, потому что у этого объекта локальные координаты относительно родителя.

![а у цилиндра всё также](https://user-images.githubusercontent.com/74662720/192109760-859d8fda-6aac-43c0-9d5a-9e7ae9ac14f0.png)

3) Теперь сделаем Cylinder самостоятельным объектом. Координаты цилиндра стали глобальными и больше не зависят ни от каких объектов.

![теперь объект не дочерний и коорты изменились](https://user-images.githubusercontent.com/74662720/192109801-6dd74e76-ae69-4983-8379-187e97482874.png)


### - Создайте три различных примера работы компонента RigidBody
Ход работы:
1) Мы можем изменить массу объекта, тогда поменяется его поведение. Например, если у сферы Mass = 1, то при падении на куб она не сдвинется с места.

![маленький шарик на месте](https://user-images.githubusercontent.com/74662720/192110107-4877f378-7a55-48b8-9fb7-5826b961892f.png)

А при Mass = 5 сфера скатывается с куба

![тяжёлый шарик укатился](https://user-images.githubusercontent.com/74662720/192110178-f8ced0c5-486e-48d8-9452-c4c07e6ba32c.png)

2) Свойство Drag регулирует сопротивление среды. Таким образом можно имитировать, например, сопротивление воздуха или воды. При Drag = 0 скорость падения сферы равна 0.87391.

![скорость при сопротивлении 0](https://user-images.githubusercontent.com/74662720/192110308-a46ed70f-b253-4694-a00d-62b19fd8b97e.png)

А при Drag = 25 скорость уже составляет 0.1962.

![скорость при сопротивлении 25](https://user-images.githubusercontent.com/74662720/192110322-27f055f1-c38c-4454-9cea-1449fb9538aa.png)

3) Во вкладке Constraints мы можем менять степени свободы. Пусть куб и сфера будут находиться на некоторой высоте от плоскости. Запустим сцену. Куб и сфера просто падают на плоскость.

![просто упали, ничего не происходит](https://user-images.githubusercontent.com/74662720/192110664-536b10ba-bc8c-4f00-b41e-23e433514ee8.png)

Теперь у куба зафиксируем положение и вращение по осям X и Y. Запустим сцену. Сфера падает, а куб остаётся "висеть" и вращается только по оси Z.

![степени свободы](https://user-images.githubusercontent.com/74662720/192110698-90e622fe-02bf-4b17-884a-67f80f8d9260.png)


## Задание 3
### Реализуйте на сцене генерацию n кубиков. Число n вводится пользователем после старта сцены.
Ход работы:
1) Cоздать InputField.

![создали InputField](https://user-images.githubusercontent.com/74662720/192112861-6ccfe7f5-8a66-4a91-929d-411a973913c4.png)

2) Создать точку появления объектов. Это будет пустой объект SpawnPoint.

![создали SpawnPoint](https://user-images.githubusercontent.com/74662720/192112893-28dde71b-1b04-4405-8d14-d9f312c8ae61.png)

3) Написать скрипт, благодаря которому будет считываться введённая переменная n и генерироваться n кубиков.

                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                public class GenerateObjects : MonoBehaviour
                {
                    public GameObject cube;
                    // Start is called before the first frame update
                    void Start()
                    {

                    }

                    // Update is called once per frame
                    void Update()
                    {

                    }

                    public void GenerateCubes (string inputInfo)
                    {
                        var n = int.Parse(inputInfo);
                        for (int i = 0; i < n; i++)
                        {
                            Instantiate(cube);
                        }
                    }
                }

4) Создать префаб куба.

![создали префаб куба](https://user-images.githubusercontent.com/74662720/192112907-ce9fb8f5-da1b-4a48-b620-3ae7b9f4d2f1.png)

5) Добавить скрипт к SpawnPoint и добавить префаб куба в переменную.

![добавили скрипт к спавну и в переменную положили префаб](https://user-images.githubusercontent.com/74662720/192112912-e55a18c8-e225-40d0-bd32-6cfcd3b9fda1.png)

6) Настроить InputField.

![настройка InputField](https://user-images.githubusercontent.com/74662720/192112929-880926d6-841a-4f7a-ab1b-1680b6a9110a.png)

7) Проверить работоспособность.

![оно работает!!!](https://user-images.githubusercontent.com/74662720/192112943-f6f60dc0-4d89-4a61-8157-cafc4d26609a.png)

## Выводы

В ходе лабораторной работы были изучены некоторые функции платформы Unity, такие как создание 3D объектов, работа с компонентом RigidBody и создание скриптов. Также было выявлено различие между координатами родительского и дочернего объектов, создана генерация объектов, количество которых задано пользователем. 


## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
