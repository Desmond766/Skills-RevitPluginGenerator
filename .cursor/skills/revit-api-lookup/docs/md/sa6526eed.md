---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.DisconnectFromServer
source: html/0eab1821-30f3-19c9-05b0-fa7c08b6e038.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.DisconnectFromServer Method

Sets the GUID of the API server to invalid value and removes all the server related data from the Rebar (ex. the current constraints and the handle tags are removed).
 Calling this method will result in a Rebar that will not react to host changes anymore, however it will still have all the properties that it used to have.

## Syntax (C#)
```csharp
public void DisconnectFromServer()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor doesn't contain a valid rebar reference.

