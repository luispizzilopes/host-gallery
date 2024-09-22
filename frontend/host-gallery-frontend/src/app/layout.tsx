import { ThemeProvider } from "@/contexts/ThemeProvider";
import { LoadingProvider } from "@/contexts/LoadingContext";
import type { Metadata } from "next";
import localFont from "next/font/local";
import { Toaster } from "@/components/ui/sonner"

import './globals.css';

const geistSans = localFont({
  src: "./fonts/GeistVF.woff",
  variable: "--font-geist-sans",
  weight: "100 900",
});
const geistMono = localFont({
  src: "./fonts/GeistMonoVF.woff",
  variable: "--font-geist-mono",
  weight: "100 900",
});

export const metadata: Metadata = {
  title: "Host Gallery",
  description: "Transforme suas imagens em memórias vivas e compartilhe com quem você ama.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="ptbr">
      <body className={`${geistSans.variable} ${geistMono.variable}`}>
        <LoadingProvider>
          <ThemeProvider attribute="class" defaultTheme="system" enableSystem disableTransitionOnChange>
            {children}
          </ThemeProvider>
        </LoadingProvider>
        <Toaster />
      </body>
    </html>
  );
}
