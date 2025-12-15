using System;
using System.Collections.Generic;

public enum EventType
{
    MotionDetected,
    FireAlert,
    DoorOpened,
    LightToggle,
    TemperatureChange
}

public class HubEvent : EventArgs
{
    public EventType Type { get; set; }
    public DateTime Time { get; set; }
    public int Priority { get; set; }

    public HubEvent(EventType type, int priority)
    {
        Type = type;
        Time = DateTime.Now;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"[{Time:HH:mm:ss}] Событие: {Type}, Приоритет: {Priority}";
    }
}

public interface ISmartDevice
{
    string Name { get; }
    void ReactToEvent(HubEvent eventData);
}

public class SmartHomeHub
{
    public event EventHandler<HubEvent> OnEvent;

    protected virtual void RaiseEvent(HubEvent hubEvent)
    {
        EventHandler<HubEvent> handler = OnEvent;

        if (handler != null)
        {
            handler(this, hubEvent);
        }
    }

    public void TriggerMotion()
    {
        Console.WriteLine("Хаб: сгенерировано событие 'Обнаружено движение'");

        HubEvent motionEvent = new HubEvent(EventType.MotionDetected, priority: 3);

        RaiseEvent(motionEvent);
    }

    public void TriggerFireAlarm()
    {
        Console.WriteLine("Хаб: сгенерировано событие 'Пожарная тревога'");

        HubEvent fireEvent = new HubEvent(EventType.FireAlert, priority: 5);

        RaiseEvent(fireEvent);
    }

    public void TriggerDoorOpened()
    {
        Console.WriteLine("Хаб: сгенерировано событие 'Дверь открыта'");

        HubEvent doorEvent = new HubEvent(EventType.DoorOpened, priority: 2);

        RaiseEvent(doorEvent);
    }

    public void TriggerTemperatureChange()
    {
        Console.WriteLine("Хаб: сгенерировано событие 'Изменение температуры'");

        HubEvent tempEvent = new HubEvent(EventType.TemperatureChange, priority: 1);

        RaiseEvent(tempEvent);
    }
}

public class SmartLamp : ISmartDevice
{
    public string Name { get; private set; }

    private bool isOn;

    public SmartLamp(string name, SmartHomeHub hub)
    {
        Name = name;
        isOn = false;

        hub.OnEvent += HandleEvent;

        Console.WriteLine($"{Name}: подключена к хабу");
    }

    private void HandleEvent(object sender, HubEvent e)
    {
        switch (e.Type)
        {
            case EventType.MotionDetected:
                TurnOn();
                break;

            case EventType.LightToggle:
                if (isOn) TurnOff();
                else TurnOn();
                break;

            case EventType.FireAlert:
                TurnOn();
                break;
        }
    }

    private void TurnOn()
    {
        if (!isOn)
        {
            isOn = true;
            Console.WriteLine($"{Name}: лампа включена");
        }
    }

    private void TurnOff()
    {
        if (isOn)
        {
            isOn = false;
            Console.WriteLine($"{Name}: лампа выключена");
        }
    }

    public void ReactToEvent(HubEvent eventData)
    {
        Console.WriteLine($"{Name}: получено прямое событие - {eventData.Type}");
        HandleEvent(null, eventData);
    }
}

public class SecuritySiren : ISmartDevice
{
    public string Name { get; private set; }

    public SecuritySiren(string name, SmartHomeHub hub)
    {
        Name = name;

        hub.OnEvent += HandleEvent;

        Console.WriteLine($"{Name}: подключена к хабу");
    }

    private void HandleEvent(object sender, HubEvent e)
    {
        if (e.Priority >= 4)
        {
            Console.WriteLine($"{Name}: ВНИМАНИЕ! Высокоприоритетное событие - {e.Type}");
            Console.WriteLine($"{Name}:  Сирена активирована!");
        }
    }

    public void ReactToEvent(HubEvent eventData)
    {
        Console.WriteLine($"{Name}: проверка события - {eventData.Type}");
        HandleEvent(null, eventData);
    }
}

public class SmartphoneApp : ISmartDevice
{
    public string Name { get; private set; }

    public SmartphoneApp(string name, SmartHomeHub hub)
    {
        Name = name;

        hub.OnEvent += HandleEvent;

        Console.WriteLine($"{Name}: подключено к хабу");
    }

    private void HandleEvent(object sender, HubEvent e)
    {
        if (e.Priority >= 3)
        {
            Console.WriteLine($"{Name}:  Уведомление: {e}");

            if (e.Priority >= 4)
            {
                Console.WriteLine($"{Name}:  Требуется ваше внимание!");
            }
        }
    }

    public void ReactToEvent(HubEvent eventData)
    {
        Console.WriteLine($"{Name}: прямое уведомление - {eventData.Type}");
        HandleEvent(null, eventData);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== ЗАПУСК СИСТЕМЫ УМНЫЙ ДОМ ===\n");

        SmartHomeHub hub = new SmartHomeHub();
        Console.WriteLine("Центральный хаб создан\n");

        SmartLamp livingRoomLamp = new SmartLamp("Лампа в гостиной", hub);
        SmartLamp kitchenLamp = new SmartLamp("Лампа на кухне", hub);
        SecuritySiren mainSiren = new SecuritySiren("Основная сирена", hub);
        SmartphoneApp userApp = new SmartphoneApp("Приложение пользователя", hub);

        Console.WriteLine("\n=== УСТРОЙСТВА ПОДКЛЮЧЕНЫ ===\n");

        Console.WriteLine("=== СЦЕНАРИЙ 1: Обнаружено движение ===");
        hub.TriggerMotion();
        Console.WriteLine();

        Console.WriteLine("=== СЦЕНАРИЙ 2: Открыта дверь ===");
        hub.TriggerDoorOpened();
        Console.WriteLine();

        Console.WriteLine("=== СЦЕНАРИЙ 3: Изменение температуры ===");
        hub.TriggerTemperatureChange();
        Console.WriteLine();

        Console.WriteLine("=== СЦЕНАРИЙ 4: ПОЖАРНАЯ ТРЕВОГА ===");
        hub.TriggerFireAlarm();
        Console.WriteLine();

        Console.WriteLine("=== ПРЯМОЕ ВЗАИМОДЕЙСТВИЕ С УСТРОЙСТВАМИ ===");

        HubEvent testEvent = new HubEvent(EventType.LightToggle, priority: 2);

        livingRoomLamp.ReactToEvent(testEvent);
        userApp.ReactToEvent(testEvent);

        Console.WriteLine("\n=== СИСТЕМА ОСТАНОВЛЕНА ===");

        Console.ReadKey();
    }
}