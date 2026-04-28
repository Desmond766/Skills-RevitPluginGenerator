---
kind: method
id: M:Autodesk.Revit.DB.Macros.Macro.Execute
source: html/e7232c95-e186-c31d-9c3e-93ab7430fd10.htm
---
# Autodesk.Revit.DB.Macros.Macro.Execute Method

Executes the macro.

## Syntax (C#)
```csharp
public void Execute()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the module is a document module and the Macro is disabled for the document,
 or there is a open transaction of the entrypoint's document,
 or the transaction mode assinged to this macro module assigned is invalid for the entrypoint's document,
 such as ReadOnly or Automatic transaction mode for the entrypoint without document,
 or this is a DB module macro but be executed in UI environment,
 or macro failed to execute.

