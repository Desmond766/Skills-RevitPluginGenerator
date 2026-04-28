---
kind: method
id: M:Autodesk.Revit.UI.ExternalEvent.Create(Autodesk.Revit.UI.IExternalEventHandler)
zh: 创建、新建、生成、建立、新增
source: html/bd97580b-25f4-ffce-0e04-aa6dd141d940.htm
---
# Autodesk.Revit.UI.ExternalEvent.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an instance of external event.

## Syntax (C#)
```csharp
public static ExternalEvent Create(
	IExternalEventHandler handler
)
```

## Parameters
- **handler** (`Autodesk.Revit.UI.IExternalEventHandler`) - An instance of IExternalEventHandler which will execute the event.

## Returns
An instance of ExternalEvent class, which will be used to invoke the event

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

