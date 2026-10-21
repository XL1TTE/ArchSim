export interface AppConfig {
  serverUrl: string
}

export const config: AppConfig = {
  serverUrl: import.meta.env.ARCHSIM_SERVER_URL || 'http://localhost:5000',
} as const
