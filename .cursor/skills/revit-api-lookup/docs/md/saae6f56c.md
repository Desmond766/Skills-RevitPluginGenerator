---
kind: type
id: T:Autodesk.Revit.DB.DataConversionMonitorScope
source: html/46b27582-3614-9776-134a-90519d645526.htm
---
# Autodesk.Revit.DB.DataConversionMonitorScope

This class is used to regsiter an application-supplied object that implements IDataConversionMonitor.
 Creating the object registers an implementation of IDataConversionMonitor supplied as constructor argument.
 When the scope object is destroyed, that object is unregistered.

## Syntax (C#)
```csharp
public class DataConversionMonitorScope : IDisposable
```

