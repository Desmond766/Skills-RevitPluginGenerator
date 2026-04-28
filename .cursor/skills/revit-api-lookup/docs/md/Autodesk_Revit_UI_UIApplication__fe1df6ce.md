---
kind: type
id: T:Autodesk.Revit.UI.UIApplication
source: html/51ca80e2-3e5f-7dd2-9d95-f210950c72ae.htm
---
# Autodesk.Revit.UI.UIApplication

Represents an active session of the Autodesk Revit user interface, providing access to
 UI customization methods, events, the main window, and the active document.

## Syntax (C#)
```csharp
public class UIApplication : IDisposable
```

## Remarks
You can access documents from the database level Application object, obtained from
 the Application property. If you have an instance of the database level Application object,
 you can construct a UIApplication instance from it.

