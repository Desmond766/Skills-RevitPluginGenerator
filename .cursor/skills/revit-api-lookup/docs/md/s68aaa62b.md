---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceLoadContext.GetCurrentlyLoadedReference
source: html/8f5826f7-3f2e-69e0-23f3-6e6c2cbdf6c6.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContext.GetCurrentlyLoadedReference Method

Returns a copy of the ExternalResourceReference currently
 in use by the containing element.

## Syntax (C#)
```csharp
public ExternalResourceReference GetCurrentlyLoadedReference()
```

## Returns
A copy of the ExternalResourceReference currently in use
 by the containing element.

## Remarks
A server may use to wish this information to, for example,
 tell whether the Revit user was previously using their
 server or not. This reference may be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no current
 value. For example, a newly-created link being loaded for the first
 time would have no currently-loaded reference.

