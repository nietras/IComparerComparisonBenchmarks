## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmarkInt.OpenComparison_FromCompareTo()
       push    rsi
       sub     rsp,20h
       mov     rsi,rcx
       mov     rcx,7FFBF4354D08h
       mov     edx,3
       call    coreclr!coreclr_shutdown_2+0xf230
       mov     rdx,1BD55C77348h
       mov     rdx,qword ptr [rdx]
       mov     rcx,rsi
       mov     rax,7FFBF4277190h
       add     rsp,20h
       pop     rsi
       jmp     rax
       add     byte ptr [rax],al
       sbb     dword ptr [00007ffc`262e5218],eax
       add     dword ptr [rax+40h],esp
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
; Total bytes of code 87
```
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmarkInt.RunOpenComparison(IComparerComparisonBenchmarks.OpenComparison`1<Int32>)
       xor     ebx,ebx
       xor     ebp,ebp
       mov     rcx,qword ptr [rsi+30h]
       cmp     dword ptr [rcx+8],0
       jle     M01_L01
M01_L00:
       mov     ecx,dword ptr [rsi+38h]
       mov     dword ptr [rsp+20h],ecx
       mov     rax,rdi
       lea     rdx,[rsp+20h]
       mov     rcx,qword ptr [rsi+30h]
       cmp     ebp,dword ptr [rcx+8]
       jae     00007ffb`f42953b5
       movsxd  r8,ebp
       mov     r8d,dword ptr [rcx+r8*4+10h]
       lea     rcx,[rax+8]
       mov     rcx,qword ptr [rcx]
       call    qword ptr [rax+18h]
       add     ebx,eax
       inc     ebp
       mov     rax,qword ptr [rsi+30h]
       cmp     dword ptr [rax+8],ebp
       jg      M01_L00
M01_L01:
       mov     eax,ebx
; Total bytes of code 71
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].IComparer()
       mov     rdx,qword ptr [rcx+8]
       mov     rax,7FFBF4287A88h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`f42a522e
       ???
       hlt
       sti
       jg      00007ffb`f42a51ff
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparer()
       mov     rdx,qword ptr [rcx+10h]
       mov     rax,7FFBF4277A90h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`f429522e
       hlt
       sti
       jg      00007ffb`f42951ff
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].TComparer_TComparer()
       movsx   rdx,byte ptr [rcx+48h]
       mov     rax,7FFBF42942F0h
       jmp     rax
       add     byte ptr [rax],al
       sbb     dword ptr [rax],eax
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],ch
       xor     eax,7FFBF43Eh
       add     byte ptr [rax],al
; Total bytes of code 48
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].TComparer_IComparer()
       mov     r8,qword ptr [rcx+8]
       mov     rdx,7FFBF43EA5B0h
       mov     rax,7FFBF42A42F0h
       jmp     rax
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`f42a522f
       ???
       hlt
       sti
       jg      M00_L00
M00_L00:
       add     byte ptr [rdi+56h],dl
       push    rbp
       push    rbx
       sub     rsp,28h
; Total bytes of code 56
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].TComparer_Comparer()
       mov     r8,qword ptr [rcx+10h]
       mov     rdx,7FFBF43EA5B0h
       mov     rax,7FFBF42A42F0h
       jmp     rax
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`f42a522f
       ???
       hlt
       sti
       jg      M00_L00
M00_L00:
       add     byte ptr [rdi+56h],dl
       push    rbp
       push    rbx
       sub     rsp,28h
; Total bytes of code 56
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].TComparer_Comparable()
       movsx   rdx,byte ptr [rcx+50h]
       mov     rax,7FFBF42942F0h
       jmp     rax
       add     byte ptr [rax],al
       sbb     dword ptr [rax],eax
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],dl
       xor     eax,7FFBF43Eh
       add     byte ptr [rax],al
; Total bytes of code 48
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].ComparisonComparer_IComparer()
       mov     rdx,qword ptr [rcx+28h]
       mov     rax,7FFBF4287A88h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`f42a522e
       ???
       hlt
       sti
       jg      00007ffb`f42a51ff
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].ComparisonComparer_TComparer()
       mov     rdx,qword ptr [rcx+40h]
       mov     rax,7FFBF42942F0h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       xor     byte ptr [rsi],dh
       hlt
       sti
       jg      00007ffb`f42951ff
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparison_FromIComparer()
       mov     rdx,qword ptr [rcx+18h]
       mov     rax,7FFBF4297A98h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`f42b522e
       hlt
       sti
       jg      00007ffb`f42b51ff
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparison_FromComparer()
       mov     rdx,qword ptr [rcx+20h]
       mov     rax,7FFBF4277A98h
       jmp     rax
       add     byte ptr [rax],al
       add     byte ptr [rcx],bl
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       add     byte ptr [rax],al
       loopne  00007ffb`f429522e
       hlt
       sti
       jg      00007ffb`f42951ff
; Total bytes of code 47
```

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparison_CreateFromIComparer()
       mov     rdi,qword ptr [rsi+8]
       mov     rcx,offset System_Private_CoreLib+0xa25490
       call    coreclr!coreclr_shutdown_2+0xee30
       mov     rbx,rax
       mov     rcx,rdi
       mov     rdx,offset System_Private_CoreLib+0xa138c8
       mov     r8,offset System_Private_CoreLib+0x172038
       call    coreclr!GC_Initialize+0x679e0
       mov     rbp,rax
       lea     rcx,[rbx+8]
       mov     rdx,rdi
       call    coreclr!coreclr_shutdown_2+0xd990
       mov     rcx,rbx
       mov     rdx,rdi
       mov     r8,rbp
       call    System.Delegate.AdjustTarget(System.Object, IntPtr)
       mov     qword ptr [rbx+18h],rax
       mov     rcx,rsi
       mov     rdx,rbx
       mov     rax,7FFBF4277A98h
; Total bytes of code 99
```
**No ILOffsetMap found**
System.Delegate.AdjustTarget(System.Object, IntPtr)

## .NET Core 2.1.9 (CoreCLR 4.6.27414.06, CoreFX 4.6.27415.01), 64bit RyuJIT
```assembly
; IComparerComparisonBenchmarks.ComparerComparisonBenchmark`2[[System.Int32, System.Private.CoreLib],[IComparerComparisonBenchmarks.IntTComparer, IComparerComparisonBenchmarks]].Comparison_CreateFromComparer()
       mov     rdi,qword ptr [rsi+10h]
       mov     rcx,offset System_Private_CoreLib+0xa25490
       call    coreclr!coreclr_shutdown_2+0xee30
       mov     rbx,rax
       mov     rcx,rdi
       mov     rdx,offset System_Private_CoreLib+0xa695f8
       mov     r8,offset System_Private_CoreLib+0x1fa5b0
       call    coreclr!GC_Initialize+0x679e0
       mov     rbp,rax
       test    rdi,rdi
       je      00007ffb`f42b5240
; Total bytes of code 58
```

