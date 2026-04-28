---
kind: method
id: M:Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.Ready
source: html/d839c136-a715-3de4-6b69-22cd65d39f81.htm
---
# Autodesk.Revit.DB.ExtensibleStorage.SchemaBuilder.Ready Method

Checks whether the builder may be used.

## Syntax (C#)
```csharp
public bool Ready()
```

## Returns
True if the SchemaBuilder has not yet been finished.

## Remarks
All newly constructed SchemaBuilders are usable until the call to the Finish method.

