---
kind: type
id: T:Autodesk.Revit.DB.PrintManager
source: html/29599e18-cad8-813e-dc6e-04350fe37944.htm
---
# Autodesk.Revit.DB.PrintManager

The PrintManager object is used to configure the global print settings.

## Syntax (C#)
```csharp
public class PrintManager : APIObject
```

## Remarks
Global print settings include PrintToFile, CombinedFile, PrintToFileName, PrintRange, CopyNumber, PrintOrderReverse, Collate.
Once PrintManager is acquired from a document, changes of its global print setting properties are not automatically 
applied toward the global print setting. Should the local setting be used, the user needs to call the Apply method. 
If the user calls SubmitPrint methods, not only that printing will use the current state of properties of the (local) print manager, 
but the setting will also be applied to the global settings.

