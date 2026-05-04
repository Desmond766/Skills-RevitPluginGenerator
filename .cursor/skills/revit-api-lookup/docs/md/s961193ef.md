---
kind: property
id: P:Autodesk.Revit.UI.RevitCommandId.HasBinding
source: html/0ac40648-62a9-23ab-c95d-1883f5fb2ac3.htm
---
# Autodesk.Revit.UI.RevitCommandId.HasBinding Property

Indicates whether a replacement of either the Execute or CanExecute events (or both) have been applied to this command.

## Syntax (C#)
```csharp
public bool HasBinding { get; }
```

## Remarks
This will not indicate if one or more applications have subscribed to the BeforeExecuted event,
 as this event is not limited to a single subscriber.

